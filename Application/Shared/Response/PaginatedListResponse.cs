namespace Application.Shared.Response;

public record PaginatedListResponse<T>(int PageNumber, int PageSize, IEnumerable<T> Values);
