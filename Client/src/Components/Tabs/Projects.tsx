import React from 'react';

const Projects: React.FC = () => {
  return (
    <section style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
      <h2>Projects</h2>
      <p>Here are some select projects that I've worked on over the past few years.</p>
      <iframe frameBorder="0" src="https://itch.io/embed/1577699" width="552" height="167">
        <a href="https://brian-sweet.itch.io/blox">Blox by Brian Sweet</a>
      </iframe>
      <br />
      <iframe frameBorder="0" src="https://itch.io/embed/659007" width="552" height="167">
        <a href="https://ericbroberic.itch.io/attack-of-the-killer-bunnies">
          Attack of the Killer Bunnies by ericbroberic, Brian Sweet, albinochicken, zhixson, MisplayJ
        </a>
      </iframe>
    </section>
  );
};

export default Projects;
