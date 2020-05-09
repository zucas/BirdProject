using Bird.Shared.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bird.Shared.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
