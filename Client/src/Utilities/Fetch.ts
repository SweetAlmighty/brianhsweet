const API_URL = import.meta.env.VITE_API_URL;

interface FetchProps {
  endpoint: string;
  onFetch: (blob: Blob) => void;
}

function Fetch({ endpoint, onFetch }: FetchProps) {
  fetch(`${API_URL}/${endpoint}`)
    .then((response) => {
      if (!response.ok) {
        throw new Error(`HTTP error: ${response.status}`);
      }
      return response.blob();
    })
    .then((data) => {
      onFetch(data);
    });
}

export default Fetch;
