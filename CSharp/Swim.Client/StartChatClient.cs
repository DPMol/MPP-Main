using chat.client;
using Swim.Networking;
using Swim.Services;

namespace Swim.Client
{
    static class StartChatClient
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //IChatServer server=new ChatServerMock();          
            IChatServices server = new ChatServerProxy("127.0.0.1", 55556);
            ClientController ctrl = new ClientController(server);
            LoginWindow win = new LoginWindow(ctrl);
            Application.Run(win);
        }
    }
}
