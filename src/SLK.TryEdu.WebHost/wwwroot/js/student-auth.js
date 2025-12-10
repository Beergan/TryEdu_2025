// Student Authentication Service - JWT Token Management
// Sử dụng localStorage để lưu JWT token cho Student (EntityUser)

const StudentAuthService = {
    TOKEN_KEY: 'student_auth_token',
    USER_KEY: 'student_user_info',

    // Lưu token vào localStorage
    saveToken(token) {
        if (token) {
            localStorage.setItem(this.TOKEN_KEY, token);
            return true;
        }
        return false;
    },

    // Lấy token từ localStorage
    getToken() {
        return localStorage.getItem(this.TOKEN_KEY);
    },

    // Lưu thông tin user vào localStorage
    saveUserInfo(userInfo) {
        if (userInfo) {
            localStorage.setItem(this.USER_KEY, JSON.stringify(userInfo));
            return true;
        }
        return false;
    },

    // Lấy thông tin user từ localStorage
    getUserInfo() {
        const userInfoStr = localStorage.getItem(this.USER_KEY);
        if (userInfoStr) {
            try {
                return JSON.parse(userInfoStr);
            } catch (e) {
                console.error('Error parsing user info:', e);
                return null;
            }
        }
        return null;
    },

    // Xóa token và user info
    clearAuth() {
        localStorage.removeItem(this.TOKEN_KEY);
        localStorage.removeItem(this.USER_KEY);
    },

    // Kiểm tra đã đăng nhập chưa
    isAuthenticated() {
        return !!this.getToken();
    },

    // Validate token với server
    async validateToken() {
        const token = this.getToken();
        if (!token) {
            return false;
        }

        try {
            const response = await fetch('/api/StudentAuth/ValidateToken', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(token)
            });

            if (response.ok) {
                const result = await response.json();
                if (result.success && result.user) {
                    this.saveUserInfo(result.user);
                    return true;
                }
            }

            // Token không hợp lệ, xóa khỏi localStorage
            this.clearAuth();
            return false;
        } catch (error) {
            console.error('Token validation error:', error);
            this.clearAuth();
            return false;
        }
    },

    // Đăng nhập
    async login(email, password, rememberMe = false) {
        try {
            const response = await fetch('/api/StudentAuth/Login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    email: email,
                    password: password,
                    rememberMe: rememberMe
                })
            });

            const result = await response.json();

            if (result.success && result.token) {
                // Lưu token và user info
                this.saveToken(result.token);
                this.saveUserInfo(result.user);
                return {
                    success: true,
                    message: result.message || 'Đăng nhập thành công',
                    user: result.user
                };
            } else {
                return {
                    success: false,
                    message: result.message || 'Đăng nhập thất bại'
                };
            }
        } catch (error) {
            console.error('Login error:', error);
            return {
                success: false,
                message: 'Lỗi kết nối đến server'
            };
        }
    },

    // Đăng ký
    async register(registerData) {
        try {
            const response = await fetch('/api/StudentAuth/Register', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(registerData)
            });

            const result = await response.json();

            if (result.success && result.token) {
                // Lưu token và user info
                this.saveToken(result.token);
                this.saveUserInfo(result.user);
                return {
                    success: true,
                    message: result.message || 'Đăng ký thành công',
                    user: result.user
                };
            } else {
                return {
                    success: false,
                    message: result.message || 'Đăng ký thất bại',
                    errors: result.errors || []
                };
            }
        } catch (error) {
            console.error('Register error:', error);
            return {
                success: false,
                message: 'Lỗi kết nối đến server'
            };
        }
    },

    // Đăng xuất
    logout() {
        this.clearAuth();
        window.location.href = '/student/login';
    },

    // Lấy Authorization header cho API calls
    getAuthHeader() {
        const token = this.getToken();
        if (token) {
            return {
                'Authorization': `Bearer ${token}`,
                'Content-Type': 'application/json'
            };
        }
        return {
            'Content-Type': 'application/json'
        };
    }
};

// Auto-validate token khi trang load (nếu có token)
document.addEventListener('DOMContentLoaded', function () {
    if (StudentAuthService.isAuthenticated()) {
        // Validate token trong background
        StudentAuthService.validateToken().then(isValid => {
            if (!isValid && window.location.pathname !== '/student/login') {
                // Token không hợp lệ, redirect về login
                StudentAuthService.logout();
            }
        });
    }
});

