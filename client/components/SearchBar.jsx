import { useEffect, useRef, useState } from 'react';
import styles from '../styles/searchBar.module.scss';
import { useLazyQuery } from '@apollo/client';
import client from '../api/apolloClient';
import { GET_THREE_GAMES_BY_NAME } from '../api/queries';
import { useRouter } from 'next/router';
import { cover_small } from '../constants/urls';

export default function SearchBar(){
    const [query, setQuery] = useState("");
    const [debouncedQuery, setDebouncedQuery] = useState(query);
    const [isFocused, setIsFocused] = useState(false);
    const ImageURL = cover_small;
    const router = useRouter();
    const inputRef = useRef(null);

    //identifing last request
    const [currentRequestId, setCurrentRequestId] = useState(0);
    const latestRequestId = useRef(0);

    useEffect(() => {
        const handler = setTimeout(() => {
          setDebouncedQuery(query.trim());
        }, 400);
    
        return () => {
          clearTimeout(handler);
        };
    }, [query]);

    const [fetchGames, { loading, error, data }] = useLazyQuery(GET_THREE_GAMES_BY_NAME, {
      client,
      fetchPolicy: 'network-only', // чтобы гарантированно не кешировалось
      onCompleted: (newData) => {
        if (latestRequestId.current === currentRequestId) {
          setGames(newData.threeGamesByName); // твой state
        }
      },
    });

    useEffect(() => {
      if (debouncedQuery.length >= 3) {
        const newId = currentRequestId + 1;
        setCurrentRequestId(newId);
        latestRequestId.current = newId;
    
        fetchGames({ variables: { name: debouncedQuery } });
      }
    }, [debouncedQuery]);

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
                latestRequestId.current === currentRequestId &&
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