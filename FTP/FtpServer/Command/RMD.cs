using System;
using System.Collections.Generic;
using System.Text;
using SuperSocket.SocketServiceCore.Command;

namespace SuperSocket.FtpService.Command
{
	public class RMD : ICommand<FtpSession>
	{
		#region ICommand<FtpSession> Members

		public void Execute(FtpSession session, CommandInfo commandData)
		{
			if (!session.Context.Logged)
				return;

			string foldername = commandData.Param;

			if (string.IsNullOrEmpty(foldername))
			{
				session.SendParameterError();
				return;
			}

            if (session.FtpServiceProvider.RemoveFolder(session.FtpContext, foldername))
            {
                session.SendResponse(Resource.RemoveOk_250, session.FtpContext.CurrentPath + "/" + foldername);
            }
            else
            {
                session.SendResponse(session.Context.Message);
            }			
		}

		#endregion
	}
}
