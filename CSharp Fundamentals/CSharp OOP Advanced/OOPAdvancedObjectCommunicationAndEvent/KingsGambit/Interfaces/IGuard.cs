using System;
using System.Collections.Generic;
using System.Text;


public interface IGuard
{
    string Name { get; set; }

    void GuardTheKing(King king);

    void StopGuardingTheKing(King king);
}

