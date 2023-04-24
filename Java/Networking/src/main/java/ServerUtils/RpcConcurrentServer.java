package ServerUtils;

import rpcprotocol.ChatClientRpcWorker;
import services.IChatServices;

import java.net.Socket;


public class RpcConcurrentServer extends AbsConcurrentServer {
    private IChatServices chatServer;
    public RpcConcurrentServer(int port, IChatServices chatServer) {
        super(port);
        this.chatServer = chatServer;
        System.out.println("Chat- ChatRpcConcurrentServer");
    }

    @Override
    protected Thread createWorker(Socket client) {
       // ChatClientRpcWorker worker=new ChatClientRpcWorker(chatServer, client);
        ChatClientRpcWorker worker=new ChatClientRpcWorker(chatServer, client);

        return new Thread(worker);
    }

    @Override
    public void stop(){
        System.out.println("Stopping services ...");
    }
}
