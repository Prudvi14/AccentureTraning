import React from 'react'
import {Link, NavLink} from 'react-router-dom'
import '../../style.css'

export default function Header() {
    return (
        <header className="sticky top-0 z-50 bg-white shadow-sm">
            <nav className="mx-auto flex max-w-screen-xl flex-wrap items-center justify-between gap-4 px-4 py-3 lg:px-6">
                <Link to="/" className="flex items-center gap-3">
                    <img
                        src="https://alexharkness.com/wp-content/uploads/2020/06/logo-2.png"
                        className="h-12"
                        alt="Logo"
                    />
                    <span className="text-lg font-semibold text-gray-900">MyWeb</span>
                </Link>
                <ul className="flex flex-wrap items-center gap-2 text-sm font-medium text-gray-700">
                    <li>
                        <NavLink
                            to="/"
                            className={({ isActive }) =>
                                `rounded-lg px-3 py-2 transition duration-200 ${
                                    isActive ? 'bg-gray-100 text-orange-700' : 'hover:bg-gray-50 hover:text-orange-700'
                                }`
                            }
                        >
                            Home
                        </NavLink>
                    </li>
                    <li>
                        <NavLink
                            to="/about"
                            className={({ isActive }) =>
                                `rounded-lg px-3 py-2 transition duration-200 ${
                                    isActive ? 'bg-gray-100 text-orange-700' : 'hover:bg-gray-50 hover:text-orange-700'
                                }`
                            }
                        >
                            About
                        </NavLink>
                    </li>
                    <li>
                        <NavLink
                            to="/contact"
                            className={({ isActive }) =>
                                `rounded-lg px-3 py-2 transition duration-200 ${
                                    isActive ? 'bg-gray-100 text-orange-700' : 'hover:bg-gray-50 hover:text-orange-700'
                                }`
                            }
                        >
                            Contact
                        </NavLink>
                    </li>
                    <li>
                        <NavLink
                            to="/github"
                            className={({ isActive }) =>
                                `rounded-lg px-3 py-2 transition duration-200 ${
                                    isActive ? 'bg-gray-100 text-orange-700' : 'hover:bg-gray-50 hover:text-orange-700'
                                }`
                            }
                        >
                            Github
                        </NavLink>
                    </li>
                </ul>

                <div className="flex flex-wrap items-center gap-2">
                    <Link
                        to="#"
                        className="rounded-lg border border-gray-200 bg-white px-4 py-2 text-sm font-medium text-gray-800 transition hover:bg-gray-50"
                    >
                        Log in
                    </Link>
                    <Link
                        to="#"
                        className="rounded-lg bg-orange-700 px-4 py-2 text-sm font-medium text-white transition hover:bg-orange-800"
                    >
                        Get started
                    </Link>
                </div>
            </nav>
        </header>
    );
}