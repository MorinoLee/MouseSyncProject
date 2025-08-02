using MouseSyncProject.Sender;
using MouseSyncProject.Receiver;

namespace MouseSyncProject
{
    public partial class MouseSync : Form
    {
        public MouseSync()
        {
            InitializeComponent();

            SenderProgram sender = new SenderProgram();
            sender.RunSender();

            ReceiverProgram receiver = new ReceiverProgram();
            receiver.RunReceiver();

        }
    }
}
