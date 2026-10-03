import React from 'react';

const About: React.FC = () => {
  return (
    <section>
      <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
        <h2>Hello!</h2>
        <p>First of all, thank you for visiting my site!</p>
      </div>

      <p>
        I'm a software engineer and former certified Scrum Master with a passion for building technology, solving problems,
        and turning ideas into working experiences. After graduating from Full Sail University in 2014, I've spent my career
        continually exploring new technologies and ways improve how teams build products. I've work on a wide-range of
        applications, including web-based product configurators with AR capabilities, 3D simulations for the U.S. Navy
        and the Department of Defense, and Enterprise-scale internal Human Resource applications and services.
      </p>

      <p>
        Outside of programming, I'm a lifelong fan of video games, anime, and other corners of nerd culture. I also
        enjoy reading, traveling, and finding new challenges to tackle. Whether I'm working on a software project,
        exploring a new place, or learning something completely unfamiliar, I'm happiest when I'm building,
        experimenting, and learning.
      </p>

      <p>
        This site is a collection of the things I'm working on, the things I'm learning, and the interests that keep me
        curious.
      </p>
    </section>
  );
};

export default About;
