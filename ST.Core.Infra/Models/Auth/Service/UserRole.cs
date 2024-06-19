using System.ComponentModel;

namespace ST.Core.Infra.Models.Auth.Service
{
	public enum UserRole
	{
		[Description("Unregistered")] Unregistered,
		[Description("Registered")] Registered

	}
}
