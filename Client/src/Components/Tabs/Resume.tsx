import React, { useEffect, useState } from 'react';
import { Document, Page, pdfjs } from 'react-pdf';
import { Pagination } from 'antd';
import fileDownload from 'js-file-download';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSpinner } from '@fortawesome/free-solid-svg-icons/faSpinner';
import Fetch from '../../Utilities/Fetch';

import 'react-pdf/dist/Page/TextLayer.css';
import 'react-pdf/dist/Page/AnnotationLayer.css';
import Endpoints from '../../Utilities/Endpoints';

pdfjs.GlobalWorkerOptions.workerSrc = new URL('pdfjs-dist/build/pdf.worker.min.mjs', import.meta.url).toString();

const Resume: React.FC = () => {
  const [numPages, setNumPages] = useState<number>();
  const [pageNumber, setPageNumber] = useState<number>(1);
  const [resumeFile, setResumeFile] = useState<File | null>(null);

  const resumeName = 'Brian-Sweet-Resume.pdf';

  function onDocumentLoadSuccess({ numPages }: { numPages: number }): void {
    setNumPages(numPages);
  }

  const handleDownload = () => {
    if (resumeFile) {
      fileDownload(resumeFile, resumeName);
    }
  };

  const handleChange = (blob: Blob) => {
    setResumeFile(new File([blob], resumeName, { type: 'application/pdf' }));
  };

  useEffect(() => {
    Fetch({ endpoint: Endpoints.GetResume, onFetch: handleChange });
  }, []);

  return (
    <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
      <h2>Resume</h2>

      {resumeFile ? (
        <>
          <p>
            You can view my resume below or download it{' '}
            <a href="#" onClick={handleDownload} target="_blank" rel="noopener noreferrer">
              here
            </a>
            .
          </p>
          <Document
            file={resumeFile}
            onLoadSuccess={onDocumentLoadSuccess}
            onLoadError={(error) => console.error('Error while loading document:', error)}
          >
            <Page pageNumber={pageNumber} />
          </Document>
          <Pagination
            pageSize={1}
            align="center"
            total={numPages}
            onChange={setPageNumber}
            defaultCurrent={pageNumber}
          />
        </>
      ) : (
        <FontAwesomeIcon icon={faSpinner} spin />
      )}
    </div>
  );
};

export default Resume;
