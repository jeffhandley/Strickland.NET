namespace Strickland
{
    public record ValidationContext();
    public record ValidationContext<T>(T Context) : ValidationContext();
}
