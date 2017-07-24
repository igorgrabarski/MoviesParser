using System;
using System.Collections.Generic;

namespace ya_move_it_parser_net
{
    public class Credit
    {
		private List<Actor> cast;
		private List<Crewman> crew;

		public List<Actor> getCast()
		{
			return cast;
		}

		public void setCast(List<Actor> cast)
		{
			this.cast = cast;
		}

		public List<Crewman> getCrew()
		{
			return crew;
		}

		public void setCrew(List<Crewman> crew)
		{
			this.crew = crew;
		}
    }
}
