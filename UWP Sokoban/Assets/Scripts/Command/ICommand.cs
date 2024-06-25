namespace Command {
    public interface ICommand {
        bool Execute();
        void Undo();
    }
}