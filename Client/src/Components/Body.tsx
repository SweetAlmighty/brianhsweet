import React from 'react';
import { Card, Tabs } from 'antd';
import About from './Tabs/About';
import Projects from './Tabs/Projects';
import Reading from './Tabs/Reading';
import Playing from './Tabs/Playing';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBook, faCircleInfo, faFileLines, faGamepad, faProjectDiagram } from '@fortawesome/free-solid-svg-icons';
import 'react-pdf/dist/Page/TextLayer.css';
import 'react-pdf/dist/Page/AnnotationLayer.css';
import Resume from './Tabs/Resume';

const Header: React.FC = () => {
  return (
    <Card style={{ marginTop: 24, borderRadius: 16 }}>
      <Tabs
        defaultActiveKey="1"
        centered
        items={[
          {
            label: 'About',
            key: '1',
            children: <About />,
            icon: <FontAwesomeIcon icon={faCircleInfo} />,
          },
          {
            label: 'Projects',
            key: '2',
            children: <Projects />,
            icon: <FontAwesomeIcon icon={faProjectDiagram} />,
          },
          {
            label: 'Resume',
            key: '3',
            children: <Resume />,
            icon: <FontAwesomeIcon icon={faFileLines} />,
          },
          {
            label: 'Reading',
            key: '4',
            children: <Reading />,
            icon: <FontAwesomeIcon icon={faBook} />,
          },
          {
            label: 'Playing',
            key: '5',
            children: <Playing />,
            icon: <FontAwesomeIcon icon={faGamepad} />,
          },
        ]}
      />
    </Card>
  );
};

export default Header;
