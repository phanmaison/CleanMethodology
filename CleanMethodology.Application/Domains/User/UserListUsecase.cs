namespace CleanMethodology.Application.Domains.User;

public class UserListUsecase
{
    public UserListUsecase()
    {
    }

    public Task ExecuteAsync()
    {
        return Task.CompletedTask;
    }

    public class Request
    {
        // search / paging criteria
    }

    public class UserList
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class Response : List<UserList>
    {
    }
}
