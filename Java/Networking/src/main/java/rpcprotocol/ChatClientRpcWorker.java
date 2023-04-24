package rpcprotocol;

import Models.User;
import dto.DTOUtils;
import dto.ParticipantDTO;
import dto.UserDTO;
import services.SwimException;
import services.IChatObserver;
import services.IChatServices;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;


public class ChatClientRpcWorker implements Runnable, IChatObserver {
    private IChatServices server;
    private Socket connection;

    private ObjectInputStream input;
    private ObjectOutputStream output;
    private volatile boolean connected;
    public ChatClientRpcWorker(IChatServices server, Socket connection) {
        this.server = server;
        this.connection = connection;
        try{
            output=new ObjectOutputStream(connection.getOutputStream());
            output.flush();
            input=new ObjectInputStream(connection.getInputStream());
            connected=true;
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void run() {
        while(connected){
            try {
                Object request=input.readObject();
                Response response=handleRequest((Request)request);
                if (response!=null){
                    sendResponse(response);
                }
            } catch (IOException e) {
                e.printStackTrace();
            } catch (ClassNotFoundException e) {
                e.printStackTrace();
            }
            try {
                Thread.sleep(1000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
        try {
            input.close();
            output.close();
            connection.close();
        } catch (IOException e) {
            System.out.println("Error "+e);
        }
    }

    private static Response okResponse=new Response.Builder().type(ResponseType.OK).build();
  //  private static Response errorResponse=new Response.Builder().type(ResponseType.ERROR).build();
    private Response handleRequest(Request request){
        Response response=null;
        if (request.type()== RequestType.LOGIN){
            System.out.println("Login request ..."+request.type());
            UserDTO udto=(UserDTO)request.data();
            User user= DTOUtils.getFromDTO(udto);
            try {
                var userR = server.login(user, this);
                var userDTO = DTOUtils.getDTO(userR);
                return new Response.Builder().type(ResponseType.LOGIN).data(userDTO).build();
            } catch (SwimException e) {
                connected=false;
                return new Response.Builder().type(ResponseType.ERROR).data(e.getMessage()).build();
            }
        }
        if (request.type()== RequestType.LOGOUT){
            System.out.println("Logout request");
           // LogoutRequest logReq=(LogoutRequest)request;
            UserDTO udto=(UserDTO)request.data();
            User user= DTOUtils.getFromDTO(udto);
            try {
                server.logout(user, this);
                connected=false;
                return okResponse;

            } catch (SwimException e) {
                return new Response.Builder().type(ResponseType.ERROR).data(e.getMessage()).build();
            }
        }
        if (request.type()== RequestType.GET_TRIALS){
            System.out.println("GetTrials request ..."+request.type());
            try {
                var trials = server.getTrials();
                var trialDTOS = DTOUtils.getDTO(trials);
                return new Response.Builder().type(ResponseType.GET_TRIALS).data(trialDTOS).build();
            } catch (SwimException e) {
                connected=false;
                return new Response.Builder().type(ResponseType.ERROR).data(e.getMessage()).build();
            }
        }
        if (request.type()== RequestType.GET_PARTICIPANTS){
            System.out.println("GetParticipants request ..."+request.type());
            Integer trialId=(Integer)request.data();
            try {
                var participants = server.getParticipants(trialId);
                var participantDTOS = DTOUtils.getDTO(participants);
                return new Response.Builder().type(ResponseType.GET_PARTICIPANTS).data(participantDTOS).build();
            } catch (SwimException e) {
                connected=false;
                return new Response.Builder().type(ResponseType.ERROR).data(e.getMessage()).build();
            }
        }
        if(request.type() == RequestType.ADD_PARTICIPANT){
            System.out.println("AddParticipants request ..."+request.type());
            var participantDTO = (ParticipantDTO)request.data();
            var participant = DTOUtils.getFromDTO(participantDTO);
            try {
                server.addParticipant(participant);
                return new Response.Builder().type(ResponseType.OK).build();
            } catch (SwimException e) {
                connected=false;
                return new Response.Builder().type(ResponseType.ERROR).data(e.getMessage()).build();
            }
        }

        return response;
    }

    private void sendResponse(Response response) throws IOException{
        System.out.println("sending response "+response);
        output.writeObject(response);
        output.flush();
    }
}
