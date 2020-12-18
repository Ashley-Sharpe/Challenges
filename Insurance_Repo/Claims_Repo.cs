using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Repo
{
    public class Claims_Repo
    {
        public Queue<Claims> _queueOfClaims = new Queue<Claims>();
        //Create
        public void AddClaimToQueue(Claims claim)
        {
            _queueOfClaims.Enqueue(claim);
        }

        //Read
        public Queue<Claims> GetClaims()
        {
            return _queueOfClaims;
        }

        //Delete
        public bool RemoveClaimItemFromQueue()
        {
           
            int initialCount = _queueOfClaims.Count;
            _queueOfClaims.Dequeue();

            if (initialCount > _queueOfClaims.Count)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

    }


}

