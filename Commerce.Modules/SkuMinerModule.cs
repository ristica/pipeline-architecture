using System;
using System.Collections.Specialized;
using Commerce.Common.Modules;

namespace Commerce.Modules
{
    public class SkuMinerModule : ICommerceModule
    {
        #region Fields

        private IMinerRepository _minerRepository;

        #endregion

        #region C-Tor

        /// <summary>
        /// for the app purposes
        /// </summary>
        public SkuMinerModule()
        {
            
        }

        /// <summary>
        /// just for unit testing
        /// </summary>
        /// <param name="minerRepository"></param>
        public SkuMinerModule(IMinerRepository minerRepository)
        {
            this._minerRepository = minerRepository;
        }

        #endregion

        #region ICommerceModule implementation

        public void Initialize(CommerceEvents events, NameValueCollection config)
        {
            events.OrderItemProcessed += args =>
            {
                // just for the case if i want to have access to the host's db
                // args.StoreRepository...

                // in the case that i want access to my own db - other then from host's
                if (this._minerRepository == null)
                {
                    this._minerRepository = new MinerRepository();
                }

                if (args.OrderLineItemData.Sku == 102)
                {
                    Console.WriteLine("\t### Product with Sku 101 was purchased on {0} ###", DateTime.Now.ToLongDateString());
                }
            };
        }

        #endregion
    }

    public interface IMinerRepository
    {
        void AccessDbMethod();
    }

    public class MinerRepository : IMinerRepository
    {
        public void AccessDbMethod()
        {
            
        }
    }
}
