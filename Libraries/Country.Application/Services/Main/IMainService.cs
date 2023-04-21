namespace Country.Application.Services.Main
{
    public interface IMainService
    {
        #region Database Services

        Task<bool> DatabaseIsReady(CancellationToken cancellationToken = default);
       

        #endregion

        #region Download Services

        Task DownloadCountries(CancellationToken cancellationToken = default);
        Task DownloadStates(CancellationToken cancellationToken = default);
        Task DownloadCities(CancellationToken cancellationToken = default);

        #endregion
    }
}
