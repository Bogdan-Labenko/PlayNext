import { useRouter } from "next/router"
import styles from "../styles/searchPage.module.scss"
import { useEffect, useState } from "react";
import { useLazyQuery, useQuery } from "@apollo/client";
import { GET_GAMES_BY_NAME } from "../api/queries";
import client from '../api/apolloClient';

export default function SearchResults() {
    const router = useRouter();
    const [searchQuery, setQuery] = useState('');
    const [gamesCount, setGameCount] = useState(0);

    const [fetchGames, { loading, error, data }] = useLazyQuery(GET_GAMES_BY_NAME, {
        client
    });

    useEffect(() => {
        if (router.isReady) {
            const searchQuery = router.query.query || '';
            setQuery(searchQuery);
            
            if (searchQuery) {
                fetchGames({ variables: { name: searchQuery, limit: 24 } });
            }
        }
    }, [router.isReady, router.query.query]);

    useEffect(() => {
        if (data?.gamesByName) {
            console.log(data.gamesByName);
            
            setGameCount(data.gamesByName.length); // Исправлена опечатка в length
        }
    }, [data]);

    return (
        <div>
            {loading && <h1>Loading...</h1>}
            {error && <h3>{error.message}</h3>}
            {data?.gamesByName && 
                <div>
                    <h2>Games with similar name: {gamesCount}</h2>
                    <hr style={{marginLeft: '100px', marginRight: 0}} />
                </div>
            }
        </div>
    )
} 