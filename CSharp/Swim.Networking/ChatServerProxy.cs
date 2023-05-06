using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Swim.Services;
using Swim.Domain.Models.UserModels;
using Swim.Domain.Models.TrialModels;
using Swim.Domain.Models.ParticipantModels;

namespace Swim.Networking
{
    public class ChatServerProxy : IChatServices
    {
        private string host;
        private int port;

        private IChatObserver client;

        private NetworkStream stream;

        private IFormatter formatter;
        private TcpClient connection;

        private Queue<Response> responses;
        private volatile bool finished;
        private EventWaitHandle _waitHandle;
        public ChatServerProxy(string host, int port)
        {
            this.host = host;
            this.port = port;
            responses = new Queue<Response>();
        }


        public void AddParticipant(Participant participant)
        {
            var participantDTO = DTOUtils.GetDTO(participant);
            sendRequest(new AddParticipantRequest { participantDTO = participantDTO });
            var response = readResponse();
            if(response is OkResponse)
            {
                return;
            }
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                closeConnection();
                throw new ChatException(err.Message);
            }
            throw new ChatException();
        }

        public Participant[] GetParticipants(Trial trial)
        {
            var trialDTO = DTOUtils.GetDTO(trial);
            sendRequest(new GetParticipantsRequest { TrialDTO = trialDTO});
            Response response = readResponse();
            if (response is GetParticipantsResponse resp)
            {
                var participantDTOs = resp.participantDTOs;
                var participants = DTOUtils.GetFromDTO(participantDTOs);
                return participants;
            }
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                closeConnection();
                throw new ChatException(err.Message);
            }
            throw new ChatException();
        }

        public virtual Trial[] GetTrials()
        {
            sendRequest(new GetTrialsRequest());
            Response response = readResponse();
            if (response is GetTrialsResponse resp)
            {
                var trialDTOs = resp.trialDTOs;
                var trials = DTOUtils.GetFromDTO(trialDTOs);
                return trials;
            }
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                closeConnection();
                throw new ChatException(err.Message);
            }
            throw new ChatException();
        }

        public virtual void Login(User user, IChatObserver client)
        {
            initializeConnection();
            UserDTO udto = DTOUtils.GetDTO(user);
            sendRequest(new LoginRequest(udto));
            Response response = readResponse();
            if (response is OkResponse)
            {
                this.client = client;
                return;
            }
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                closeConnection();
                throw new ChatException(err.Message);
            }
        }

        public virtual void Logout(User user, IChatObserver client)
        {
            UserDTO udto = DTOUtils.GetDTO(user);
            sendRequest(new LogoutRequest(udto));
            Response response = readResponse();
            closeConnection();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new ChatException(err.Message);
            }
        }

        private void closeConnection()
        {
            finished = true;
            try
            {
                stream.Close();

                connection.Close();
                _waitHandle.Close();
                client = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }

        private void sendRequest(Request request)
        {
            try
            {
                formatter.Serialize(stream, request);
                stream.Flush();
            }
            catch (Exception e)
            {
                throw new ChatException("Error sending object " + e);
            }

        }

        private Response readResponse()
        {
            Response response = null;
            try
            {
                _waitHandle.WaitOne();
                lock (responses)
                {
                    //Monitor.Wait(responses); 
                    response = responses.Dequeue();

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return response;
        }
        private void initializeConnection()
        {
            try
            {
                connection = new TcpClient(host, port);
                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                finished = false;
                _waitHandle = new AutoResetEvent(false);
                startReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        private void startReader()
        {
            Thread tw = new Thread(run);
            tw.Start();
        }


        private void handleUpdate(UpdateResponse update)
        {
            
        }
        public virtual void run()
        {
            while (!finished)
            {
                try
                {
                    object response = formatter.Deserialize(stream);
                    Console.WriteLine("response received " + response);
                    if (response is UpdateResponse)
                    {
                        handleUpdate((UpdateResponse)response);
                    }
                    else
                    {

                        lock (responses)
                        {


                            responses.Enqueue((Response)response);

                        }
                        _waitHandle.Set();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Reading error " + e);
                }

            }
        }

    }
}
