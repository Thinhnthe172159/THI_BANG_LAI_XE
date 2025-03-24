using System;
using System.Collections.Generic;

namespace THI_BANG_LAI_XE.Models;

public partial class Notification
{
    public long Id { get; set; }

    public long? Receiver { get; set; }

    public DateTime DateTime { get; set; } = DateTime.Now;

    public string? Title { get; set; }

    public string? Content { get; set; }

    public int IsRead { get; set; } = 0;

    public long? Sender { get; set; }

    public virtual User? ReceiverNavigation { get; set; }

    public virtual User? SenderNavigation { get; set; }
}
