namespace WHC.OrderWater.Commons.Threading
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public delegate void RunQueuedWorkerCompletedEventHandler(object sender, QueuedWorkerCompletedEventArgs e);
}
