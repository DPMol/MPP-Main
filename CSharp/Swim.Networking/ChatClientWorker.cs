﻿using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Swim.Services;
using Swim.Domain.Models.UserModels;
using Swim.Domain.Models.ParticipantModels;
using Swim.Domain.Models.TrialModels;

namespace Swim.Networking
{
    public class ChatClientWorker : IChatObserver //, Runnable
    {
        private IChatServices server;
        private TcpClient connection;

        private NetworkStream stream;
        private IFormatter formatter;
        private volatile bool connected;
        public ChatClientWorker(IChatServices server, TcpClient connection)
        {
            this.server = server;
            this.connection = connection;
            try
            {

                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                connected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public virtual void run()
        {
            while (connected)
            {
                try
                {
                    object request = formatter.Deserialize(stream);
                    object response = handleRequest((Request)request);
                    if (response != null)
                    {
                        sendResponse((Response)response);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }

                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            try
            {
                stream.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }
        }

        private Response handleRequest(Request request)
        {
            Response response = null;
            if(request is AddParticipantRequest addParticipantRequest)
            {
                var participantDTO = addParticipantRequest.participantDTO;
                var participant = DTOUtils.GetFromDTO(participantDTO);
                try
                {
                    lock (server)
                    {
                        server.AddParticipant(participant);
                    }
                    return new OkResponse();
                }
                catch (ChatException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }
            if (request is GetParticipantsRequest getParticipantsRequest)
            {
                Console.WriteLine("GetParticipantsRequest ...");
                var trialDTO = getParticipantsRequest.TrialDTO;
                var trial = DTOUtils.GetFromDTO(trialDTO);
                try
                {
                    Participant[] participants;
                    lock (server)
                    {
                        participants = server.GetParticipants(trial);
                    }
                    var participantDTOs = DTOUtils.GetDTO(participants);
                    return new GetParticipantsResponse
                    {
                        participantDTOs = participantDTOs,
                    };
                }
                catch (ChatException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }
            if (request is GetTrialsRequest)
            {
                Console.WriteLine("GetTrialsRequest ...");
                try
                {
                    Trial[] trials;

                    lock (server)
                    {
                        trials = server.GetTrials();
                    }

                    var trialDTOs = DTOUtils.GetDTO(trials);
                    return new GetTrialsResponse
                    {
                        trialDTOs = trialDTOs
                    };
                }
                catch (ChatException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }
            if (request is LoginRequest)
            {
                Console.WriteLine("Login request ...");
                LoginRequest logReq = (LoginRequest)request;
                UserDTO udto = logReq.User;
                User user = DTOUtils.GetFromDTO(udto);
                try
                {
                    lock (server)
                    {
                        server.Login(user, this);
                    }
                    return new OkResponse();
                }
                catch (ChatException e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
            }
            if (request is LogoutRequest)
            {
                Console.WriteLine("Logout request");
                LogoutRequest logReq = (LogoutRequest)request;
                UserDTO udto = logReq.User;
                User user = DTOUtils.GetFromDTO(udto);
                try
                {
                    lock (server)
                    {

                        server.Logout(user, this);
                    }
                    connected = false;
                    return new OkResponse();

                }
                catch (ChatException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }
            
            return response;
        }

        private void sendResponse(Response response)
        {
            Console.WriteLine("sending response " + response);
            lock (stream)
            {
                formatter.Serialize(stream, response);
                stream.Flush();
            }

        }
    }
}
