import NavBar from './NavBar'
import SearchBar from './SearchBar'

export default function Layout({ children }) {
  return (
    <div>
      <NavBar />
      <SearchBar />
      <main>{children}</main>
    </div>
  )
}