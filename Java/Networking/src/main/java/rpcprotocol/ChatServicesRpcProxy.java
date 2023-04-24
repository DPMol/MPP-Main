package rpcprotocol;

import Models.Participant;
import Models.Trial;
import Models.User;
import dto.DTOUtils;
import dto.ParticipantDTO;
import dto.TrialDTO;
import dto.UserDTO;
import services.SwimException;
import services.IChatObserver;
import services.IChatServices;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.util.List;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.LinkedBlockingQueue;


public class ChatServicesRpcProxy implements IChatServices {
    private String host;
    private int port;

    private IChatObserver client;

    private ObjectInputStream input;
    private ObjectOutputStream output;
    private Socket connection;

    private BlockingQueue<Response> qresponses;
    private volatile boolean finished;
    public ChatServicesRpcProxy(String host, int port) {
        this.host = host;
        this.port = port;
        qresponses=new LinkedBlockingQueue<Response>();
    }

    public Participant[] getParticipants(Integer trialId) throws SwimException {
        Request req=new Request.Builder().type(RequestType.GET_PARTICIPANTS).data(trialId).build();
        sendRequest(req);
        Response response=readResponse();
        if (response.type()== ResponseType.ERROR){
            String err=response.data().toString();
            throw new SwimException(err);
        }
        ParticipantDTO[] participantDTOS=(ParticipantDTO[])response.data();
        Participant[] participants= DTOUtils.getFromDTO(participantDTOS);
        return participants;
    }

    @Override
    public void addParticipant(Participant participant) throws SwimException {
        var participantDTO = DTOUtils.getDTO(participant);
        Request req=new Request.Builder().type(RequestType.ADD_PARTICIPANT).data(participantDTO).build();
        sendRequest(req);
        Response response=readResponse();
        if (response.type() == ResponseType.ERROR){
            String err=response.data().toString();
            throw new SwimException(err);
        }
    }

    public Trial[] getTrials() throws SwimException {
        Request req=new Request.Builder().type(RequestType.GET_TRIALS).build();
        sendRequest(req);
        Response response=readResponse();
        if (response.type()== ResponseType.ERROR){
            String err=response.data().toString();
            throw new SwimException(err);
        }
        TrialDTO[] trialDTOS=(TrialDTO[])response.data();
        Trial[] trials= DTOUtils.getFromDTO(trialDTOS);
        return trials;
    }

    public User login(User user, IChatObserver client) throws SwimException {
        initializeConnection();
        UserDTO udto= DTOUtils.getDTO(user);
        Request req=new Request.Builder().type(RequestType.LOGIN).data(udto).build();
        sendRequest(req);
        Response response=readResponse();
        if (response.type()== ResponseType.LOGIN){
            this.client=client;
            UserDTO userDTO = (UserDTO) response.data();
            User userR = DTOUtils.getFromDTO(userDTO);
            return userR;
        }
        if (response.type()== ResponseType.ERROR){
            String err=response.data().toString();
            closeConnection();
            throw new SwimException(err);
        }
        return null;
    }

    public void logout(User user, IChatObserver client) throws SwimException {
        UserDTO udto= DTOUtils.getDTO(user);
        Request req=new Request.Builder().type(RequestType.LOGOUT).data(udto).build();
        sendRequest(req);
        Response response=readResponse();
        closeConnection();
        if (response.type()== ResponseType.ERROR){
            String err=response.data().toString();
            throw new SwimException(err);
        }
    }

    private void closeConnection() {
        finished=true;
        try {
            input.close();
            output.close();
            connection.close();
            client=null;
        } catch (IOException e) {
            e.printStackTrace();
        }

    }

    private void sendRequest(Request request)throws SwimException {
        try {
            output.writeObject(request);
            output.flush();
        } catch (IOException e) {
            throw new SwimException("Error sending object "+e);
        }

    }

    private Response readResponse() throws SwimException {
        Response response=null;
        try{

            response=qresponses.take();

        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        return response;
    }
    private void initializeConnection() throws SwimException {
        try {
            connection=new Socket(host,port);
            output=new ObjectOutputStream(connection.getOutputStream());
            output.flush();
            input=new ObjectInputStream(connection.getInputStream());
            finished=false;
            startReader();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
    private void startReader(){
        Thread tw=new Thread(new ReaderThread());
        tw.start();
    }


    private void handleUpdate(Response response){

    }

    private boolean isUpdate(Response response){
       return false;
    }
    private class ReaderThread implements Runnable{
        public void run() {
            while(!finished){
                try {
                    Object response=input.readObject();
                    System.out.println("response received "+response);
                    if (isUpdate((Response)response)){
                        handleUpdate((Response)response);
                    }else{

                        try {
                            qresponses.put((Response)response);
                        } catch (InterruptedException e) {
                            e.printStackTrace();
                        }
                    }
                } catch (IOException e) {
                    System.out.println("Reading error "+e);
                } catch (ClassNotFoundException e) {
                    System.out.println("Reading error "+e);
                }
            }
        }
    }
}
