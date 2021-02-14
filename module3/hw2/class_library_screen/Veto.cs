using System;
namespace class_library_screen
{

    public class VetoEventArgs : EventArgs
    {
        public string Proposal { get; private set; }
        public VetoVoter VetoBy { get; set; }
        public VetoEventArgs(string proposal, VetoVoter voter = null)
        {
            Proposal = proposal;
            VetoBy = voter;
        }

        public override string ToString()
        {
            string noVeto = "No veto.";
            string vetoBy = "Veto by:";
            return $"Proposal: {Proposal}. {(VetoBy == null ? noVeto :vetoBy + VetoBy.Name)}";
        }
    }

    public class VetoCommision
    {

        public event EventHandler<VetoEventArgs> OnVote;

        public VetoEventArgs Vote(string Proposal)
        {
            VetoEventArgs e = new VetoEventArgs(Proposal, null);
            OnVote?.Invoke(this,e);
            return e;
        }
    }

    public class VetoVoter
    {
        public string Name { get; private set; }

        public VetoVoter(string Name)
        {
            this.Name = Name;
        }

        public void VetoHandler(object sender, VetoEventArgs e)
        {
            if (e.VetoBy == null)
            {
                Random rnd = new Random();
                if (rnd.Next(0, 5) == 3) e.VetoBy = this;
            }
        }

    }
}