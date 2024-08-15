import React, { useState } from 'react';
import axios from 'axios';

const URLShortener = () => {
    const [originalUrl, setOriginalUrl] = useState('');
    const [loading, setLoading] = useState(false);
    const [shortenedUrl, setShortenedUrl] = useState('');
    const [error, setError] = useState('');

    const shortenLink = 'string'; // Placeholder, this can be dynamically set as needed

    const handleSubmit = async (event) => {
        event.preventDefault();
        setLoading(true);
        setError('');
        setShortenedUrl('');

        try {
            const response = await axios.post('http://localhost:5038/gateway/userlinks/create', {
                Link: originalUrl,
                shortenLink: shortenLink,
            });

            setLoading(false);
            if (response.data.ShortenLink) {
                setShortenedUrl(response.data.ShortenLink);
            } else {
                setError('Failed to shorten the URL.');
            }
        } catch (error) {
            setLoading(false);
            setError('An error occurred: ' + error.message);
            console.error('Error:', error);
        }
    };

    return (
        <div className="container">
            <h1>URL Shortener</h1>
            <form onSubmit={handleSubmit}>
                <label htmlFor="originalUrl">Original URL:</label>
                <input
                    type="url"
                    id="originalUrl"
                    name="originalUrl"
                    value={originalUrl}
                    onChange={(e) => setOriginalUrl(e.target.value)}
                    required
                />
                <button type="submit">Shorten</button>
            </form>
            {loading && <div id="loading">Loading...</div>}
            {shortenedUrl && (
                <div id="shortenedUrl">
                    Shortened URL: <a href={shortenedUrl} target="_blank" rel="noopener noreferrer">{shortenedUrl}</a>
                </div>
            )}
            {error && <div id="error" style={{ color: 'red' }}>{error}</div>}
        </div>
    );
};

export default URLShortener;
