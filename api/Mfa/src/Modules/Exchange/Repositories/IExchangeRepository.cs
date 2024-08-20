namespace Mfa.Modules.Host;

public interface IHostRepository {
    Task<IEnumerable<HostModel>> GetHosts(GetHostsRequest req);
    Task<HostModel?> GetHostById(int id);
    Task<HostModel?> GetHostById(int id, GetHostRequest req);
    Task CreateHost(HostModel host);
    Task CreateHosts(IEnumerable<HostModel> hosts);
    Task UpdateHost(HostModel host, UpdateHostRequest req);
    Task DeleteHost(HostModel host);
}