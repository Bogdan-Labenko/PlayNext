import { useEffect, useRef, useState } from 'react';
import styles from '../styles/searchBar.module.scss';
import { useLazyQuery } from '@apollo/client';
import client from '../api/apolloClient';
import { GET_THREE_GAMES_BY_NAME } from '../api/queries';
import { useRouter } from 'next/router';

export default function SearchBar(){
    const [query, setQuery] = useState("");
    const [debouncedQuery, setDebouncedQuery] = useState(query);
    const [isFocused, setIsFocused] = useState(false);
    const ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_small/"
    const router = useRouter();
    const inputRef = useRef(null);

    useEffect(() => {
        const handler = setTimeout(() => {
          setDebouncedQuery(query.trim());
        }, 400);
    
        return () => {
          clearTimeout(handler);
        };
    }, [query]);

    const [fetchGames, { loading, error, data }] = useLazyQuery(GET_THREE_GAMES_BY_NAME, {
        client
    });

    useEffect(() => {
      console.log(data);
      
        if (debouncedQuery.length >= 3) {
          fetchGames({ variables: { name: debouncedQuery } });
        }
    }, [debouncedQuery, fetchGames]);

    function handleKeyDown(e){
        if (e.key === "Enter") {
            if (!query.trim()) return;
            
            inputRef.current.blur();
            router.push(`/search?query=${encodeURIComponent(query)}`);
        }
    }

    return <div className={styles.searchBlock}
        onBlur={() => setQuery('')}
    >
        <div className={styles.arrow}>
            <img src="/chevron-l.png" />
        </div>
        <div className={`${styles.searchBar} ${(isFocused && debouncedQuery.length >= 3) ? styles.searchBarResult : ""}`}>
            <input 
                placeholder='Search'
                type="text"
                onChange={(e) => setQuery(e.target.value)}
                value={query}
                onFocus={() => setIsFocused(true)}
                onKeyDown={handleKeyDown}
                ref={inputRef}
            />
            <button 
                style={{fontFamily: "arial"}}
                onClick={() => setDebouncedQuery('')}
            >&#215;</button>
        </div>
      {((isFocused && debouncedQuery.length >= 3)) ? (
        <div className={styles.results}>
          {loading && <p>Loading...</p>}
          {error && <p style={{ color: "red" }}>Error: {error.message}</p>}
          {data?.threeGamesByName.length > 0 ? (
              data.threeGamesByName.map((game) => (
                <a href='/game' className={styles.gameItem} key={game.id}>
                    <div className={styles.imgBox}>
                        <img src={`${ImageURL}${game.cover?.imageId}.jpg`} alt="cover" />
                    </div>
                    <div className={styles.textBox}>
                        <h2>{game.name}</h2>
                    </div>
                </a>
              ))
          ) : (
            !loading && <p>No results found</p>
          )}
        </div>
      ) : ""}
    </div>
}