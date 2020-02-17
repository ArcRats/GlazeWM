﻿using LarsWM.Infrastructure.Bussing;
using LarsWM.Domain.Monitors;
using LarsWM.Domain.Workspaces.Commands;

namespace LarsWM.Domain.Workspaces.CommandHandlers
{
    class CreateWorkspaceHandler : ICommandHandler<CreateWorkspaceCommand>
    {
        private WorkspaceService _workspaceService;

        public CreateWorkspaceHandler(WorkspaceService workspaceService)
        {
            _workspaceService = workspaceService;
        }

        public CommandResponse Handle(CreateWorkspaceCommand command)
        {
            var newWorkspace = new Workspace(command.WorkspaceName);
            _workspaceService.Workspaces.Add(newWorkspace);

            return new CommandResponse(true, newWorkspace.Id);
        }
    }
}