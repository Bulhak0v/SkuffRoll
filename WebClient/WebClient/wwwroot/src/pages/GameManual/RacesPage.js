import React from 'react';
import DetailPageLayout from '../../components/DetailPageLayout';
import RacesContent from './RacesContent';

const RacesPage = () => {
  return (
    <DetailPageLayout pageTitle="Races" backLink="/game-manual">
      <RacesContent />
    </DetailPageLayout>
  );
};

export default RacesPage;