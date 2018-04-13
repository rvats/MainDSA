using MainDSA.DataStructures.Trees;

namespace MainDSA.Quizes
{
    public class TreeLinkNodeOperations
    {
        public void Connect(TreeLinkNode root)
        {
            if (root == null)
                return;

            TreeLinkNode lastHead = root;//prevous level's head 
            TreeLinkNode lastCurrent = null;//previous level's pointer
            TreeLinkNode currentHead = null;//currnet level's head 
            TreeLinkNode current = null;//current level's pointer

            while (lastHead != null)
            {
                lastCurrent = lastHead;

                while (lastCurrent != null)
                {
                    //left child is not null
                    if (lastCurrent.left != null)
                    {
                        if (currentHead == null)
                        {
                            currentHead = lastCurrent.left;
                            current = lastCurrent.left;
                        }
                        else
                        {
                            current.next = lastCurrent.left;
                            current = current.next;
                        }
                    }

                    //right child is not null
                    if (lastCurrent.right != null)
                    {
                        if (currentHead == null)
                        {
                            currentHead = lastCurrent.right;
                            current = lastCurrent.right;
                        }
                        else
                        {
                            current.next = lastCurrent.right;
                            current = current.next;
                        }
                    }

                    lastCurrent = lastCurrent.next;
                }

                //update last head
                lastHead = currentHead;
                currentHead = null;
            }
        }
    }
}
