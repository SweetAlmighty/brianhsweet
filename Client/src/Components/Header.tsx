import React, { useEffect, useState } from 'react';
import { Avatar, Card, Col, Row, Space, Typography } from 'antd';
import { faGithub, faLinkedin, faSteam, faItchIo } from '@fortawesome/free-brands-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faEnvelope } from '@fortawesome/free-solid-svg-icons/faEnvelope';
import { faSpinner } from '@fortawesome/free-solid-svg-icons/faSpinner';
import Fetch from '../Utilities/Fetch';
import Endpoints from '../Utilities/Endpoints';

const { Title, Paragraph } = Typography;

const Header: React.FC = () => {
  const [profileImage, setProfileImage] = useState<File | null>(null);

  const handleChange = (blob: Blob) => {
    setProfileImage(new File([blob], 'profile.jpeg', { type: 'image/jpeg' }));
  };

  useEffect(() => {
    Fetch({ endpoint: Endpoints.GetProfilePicture, onFetch: handleChange });
  }, []);

  return (
    <Card style={{ boxShadow: '0 8px 24px rgba(0, 0, 0, 0.08)', borderRadius: 16 }}>
      <Row gutter={[24, 24]} align="middle">
        <Col xs={24} md={8} style={{ textAlign: 'center' }}>
          {profileImage ? (
            <Avatar size={140} src={URL.createObjectURL(profileImage)} alt="Me" />
          ) : (
            <FontAwesomeIcon icon={faSpinner} spin />
          )}
        </Col>
        <Col xs={24} md={16}>
          <Title level={2} style={{ marginBottom: 8 }}>
            Brian Hall Sweet
          </Title>
          <Paragraph type="secondary" style={{ marginBottom: 16 }}>
            Software Engineer | Game Developer | Gamer
          </Paragraph>
          <Space size="large">
            <a href="https://github.com/SweetAlmighty" target="_blank" rel="noreferrer">
              <FontAwesomeIcon icon={faGithub} size="2xl" color="#000" />
            </a>
            <a href="https://linkedin.com/in/brian-hall-sweet" target="_blank" rel="noreferrer">
              <FontAwesomeIcon icon={faLinkedin} size="2xl" color="#000" />
            </a>
            <a href="https://steamcommunity.com/id/mrsweetalmighty/" target="_blank" rel="noreferrer">
              <FontAwesomeIcon icon={faSteam} size="2xl" color="#000" />
            </a>
            <a href="https://brian-sweet.itch.io/" target="_blank" rel="noreferrer">
              <FontAwesomeIcon icon={faItchIo} size="2xl" color="#000" />
            </a>
            <a href="mailto:hello@brianhsweet.com">
              <FontAwesomeIcon icon={faEnvelope} size="2xl" color="#000" />
            </a>
          </Space>
        </Col>
      </Row>
    </Card>
  );
};

export default Header;
