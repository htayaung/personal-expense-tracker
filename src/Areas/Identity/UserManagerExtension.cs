using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Microsoft.AspNetCore.Identity;

public static class UserManagerExtension
{
    public static string GetFullName(this UserManager<ApplicationUser> userManager, ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentNullException(nameof(principal));
        }

        var userId = userManager.GetUserId(principal) ?? throw new Exception("Invalid user");
        var user = userManager.Users.SingleOrDefault(x => x.Id == Guid.Parse(userId));

        return user?.FullName;
    }

    public static async Task<string> GetFullNameAsync(this UserManager<ApplicationUser> userManager, ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentNullException(nameof(principal));
        }

        var userId = userManager.GetUserId(principal) ?? throw new Exception("Invalid user");
        var user = await userManager.Users.SingleOrDefaultAsync(x => x.Id == Guid.Parse(userId));

        return user?.FullName;
    }

    public static Guid GetUniqueUserId(this UserManager<ApplicationUser> userManager, ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentNullException(nameof(principal));
        }

        var userId = userManager.GetUserId(principal) ?? Guid.Empty.ToString();
        return Guid.Parse(userId);
    }
}
