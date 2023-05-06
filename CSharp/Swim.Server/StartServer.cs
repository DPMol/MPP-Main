using Swim.Data.Repositories.UserRepositories;
using Swim.Networking;
using Swim.Services;
using System.Net.Sockets;

namespace Swim.Server
{
    class StartServer
    {
        static void Main(string[] args)
        {

            // IUserRepository userRepo = new UserRepositoryMock();
            //  IUserRepository userRepo=new UserRepositoryDb();
            // IMessageRepository messageRepository=new MessageRepositoryDb();
            IUserRepository userRepo = new UserRepository();
            IChatServices serviceImpl = new ChatServerImpl(userRepo);

            // IChatServer serviceImpl = new ChatServerImpl();
            SerialChatServer server = new SerialChatServer("127.0.0.1", 55556, serviceImpl);
            server.Start();
            Console.WriteLine("Server started ...");
            //Console.WriteLine("Press <enter> to exit...");
            Console.ReadLine();

        }
    }

    public class SerialChatServer : ConcurrentServer
    {
        private IChatServices server;
        private ChatClientWorker worker;
        public SerialChatServer(string host, int port, IChatServices server) : base(host, port)
        {
            this.server = server;
            Console.WriteLine("SerialChatServer...");
        }
        protected override Thread createWorker(TcpClient client)
        {
            worker = new ChatClientWorker(server, client);
            return new Thread(new ThreadStart(worker.run));
        }
    }
}
