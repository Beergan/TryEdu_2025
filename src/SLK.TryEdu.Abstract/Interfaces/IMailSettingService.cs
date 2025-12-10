using System;
using System.Threading.Tasks;

namespace SLK.TryEdu.Abstract
{
	public interface IMailSettingService
	{
		Task SendMail(params MailRequest[] mails);
	}
}
