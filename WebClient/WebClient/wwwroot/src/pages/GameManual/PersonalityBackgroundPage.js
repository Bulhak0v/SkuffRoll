import React from 'react';
import DetailPageLayout from '../../components/DetailPageLayout';
import PersonalityBackgroundContent from './PersonalityBackgroundContent';

const PersonalityBackgroundPage = () => {
  return (
    <DetailPageLayout pageTitle="Personality and Background" backLink="/game-manual">
      <PersonalityBackgroundContent />
    </DetailPageLayout>
  );
};

export default PersonalityBackgroundPage;