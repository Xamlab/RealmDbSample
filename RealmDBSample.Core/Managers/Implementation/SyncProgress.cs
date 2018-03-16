namespace RealmDBSample.Core.Managers.Implementation
{
    public class SyncProgress
    {
        public SyncProgress(double totalTransferred, double totalTransferable)
        {
            TotalTransferred = totalTransferred;
            TotalTransferable = totalTransferable;
        }

        public double TotalTransferred { get; set; }
        public double TotalTransferable { get; set; }
    }
}