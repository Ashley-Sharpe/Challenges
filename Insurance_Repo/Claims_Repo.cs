using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Repo
{
   public class Claims_Repo
    {
        public bool EnquingClaimToQueue(Claim content)
        {
            int claimLength = _queue.Count();
            _queue.Enqueue(content);
            bool wasAdded = claimLength + 1 == _queue.Count();
            return wasAdded;
        }

        public void CreateQueue(Claim content)
        {
            _queue.Enqueue(content);
        }

    }
}
