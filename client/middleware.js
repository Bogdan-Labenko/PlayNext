// middleware.js
import { NextResponse } from 'next/server';
import { NextRequest } from 'next/server';

// Проверяем авторизацию пользователя
export function middleware(request) {
  // Читаем токен из cookie
  const token = request.cookies.get('token'); // Считываем token из cookie

  // Список путей, которые требуют авторизации
  const protectedPaths = ['/dashboard'];

  // Проверяем, нужно ли делать перенаправление
  if (protectedPaths.some(path => request.url.includes(path))) {
    // Если пути защищены и нет токена, перенаправляем на главную
    if (!token) {
      return NextResponse.redirect(new URL('/', request.url));
    }
  }

  return NextResponse.next();
}

// Указываем, для каких путей должен работать middleware
export const config = {
  matcher: ['/dashboard'], // Путь(и), для которых требуется защита
};