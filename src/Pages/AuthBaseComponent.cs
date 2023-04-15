using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using PersonalExpenseTracker.Data;

namespace PersonalExpenseTracker.Pages;

public abstract class AuthBaseComponent : ComponentBase
{
    [Inject]
    protected IUnitOfWork UnitOfWork { get; set; }

    [Inject]
    protected AuthenticationStateProvider AuthenticationState { get; set; }

    [Inject]
    protected UserManager<ApplicationUser> UserManager { get; set; }

    /// <summary>
    /// Current logged in user id
    /// </summary>
    protected Guid UserId
    {
        get
        {
            return GetUserId();
        }
    }

    protected Guid GetUserId()
    {
        var user = AuthenticationState.GetAuthenticationStateAsync().Result.User;
        return UserManager.GetUniqueUserId(user);
    }

    protected async Task<Guid> GetUserIdAsync()
    {
        var user = (await AuthenticationState.GetAuthenticationStateAsync()).User;
        return UserManager.GetUniqueUserId(user);
    }
}
