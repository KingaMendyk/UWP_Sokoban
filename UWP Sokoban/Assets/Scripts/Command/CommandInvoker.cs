using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker {
    private Stack<ICommand> undoStack;
    private Stack<ICommand> redoStack;
    
    public CommandInvoker() {
        undoStack = new Stack<ICommand>();
        redoStack = new Stack<ICommand>();
    }

    public void ExecuteCommand(ICommand command) {
        bool success = command.Execute();
        Debug.Log(success);

        if (success) {
            undoStack.Push(command);
            redoStack.Clear();
        }
    }

    public void UndoCommand() {
        if (undoStack.Count == 0) {
            return;
        }
            
        ICommand command = undoStack.Pop();
        command.Undo();
        redoStack.Push(command);
    }

    public void RedoCommand() {
        if (redoStack.Count == 0) {
            return;
        }
            
        ICommand command = redoStack.Pop();
        command.Execute();
        undoStack.Push(command);
    }
}
