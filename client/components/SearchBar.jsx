import styles from '../styles/searchBar.module.scss';

export default function SearchBar(){
    return <div className={styles.searchBlock}>
        <div className={styles.arrow}>
            <img src="/chevron-l.png" />
        </div>
        <div className={styles.searchBar}>
            <input placeholder='Search' type="text" />
            <button style={{fontFamily: "arial"}}>&#215;</button>
        </div>
    </div>
}