using System;
using System.Collections.Specialized;
using Commerce.Common.Modules;

namespace Commerce.Modules
{
    public class ItemPromotionModule : ICommerceModule
    {
        #region Fields

        private DateTime _startDate;
        private DateTime _endDate;

        #endregion

        #region ICommecreModule implementation

        public void Initialize(CommerceEvents events, NameValueCollection config)
        {
            var promotionStartDate = config["startPromotionDate"];
            if (string.IsNullOrWhiteSpace(promotionStartDate))
            {
                throw new ArgumentNullException("start date is missing");
            }

            var promotionEndDate = config["endPromotionDate"];
            if (string.IsNullOrWhiteSpace(promotionEndDate))
            {
                throw new ArgumentNullException("end date is missing");
            }

            this._startDate = Convert.ToDateTime(promotionStartDate);
            this._endDate = Convert.ToDateTime(promotionEndDate);

            events.OrderItemProcessed += args =>
            {
                var today = DateTime.Today;
                if (today < this._startDate || today > this._endDate) return;

                if (args.OrderLineItemData.Sku == 102)
                {
                    args.OrderLineItemData.PurchasePrice -= 30;
                }
            };
        }

        #endregion
    }
}
