const App = getApp();

Page({
    data: {
        canIUse: wx.canIUse('button.open-type.getUserInfo'),
        logged: !1
    },
    onShow() {
        var self = this;
        wx.getStorage({
            key: 'token',
            success: function (res) {
                self.setData({
                    logged: !!res.data
                });
                res.data && setTimeout(self.goIndex, 1500);
            }
        });
    },
    goIndex() {
        wx.switchTab({
            url: '/page/component/index'
        });
    },
    login() {
        var self = this;
        wx.login({
            success(res) {
                if (res.code) {
                    self.getUserInfo(res.code);
                } else {
                    console.log('登录失败！' + res.errMsg);
                }
            }
        });
    },
    getUserInfo(code) {
        var self = this;
        wx.getUserInfo({
            withCredentials: true,
            success: function (res_user) {
                self.onLogin(code, res_user);
            }
        });
    },
    onLogin(code, res_user) {
        var self = this;
        wx.request({
            url: 'http://localhost:50997/api/WxOpen/OnLogin',
            method: 'POST',
            data: {
                code: code,
                rawData: res_user.rawData,
                signature: res_user.signature,
                encryptedData: res_user.encryptedData,
                iv: res_user.iv
            },
            success: function (res) {
                wx.setStorage({
                    key: "token",
                    data: res.data
                });
                self.goIndex();
            },
            fail: function (res) {
                wx.showModal({
                    title: '登录失败',
                    content: msg,
                    showCancel: true
                });
            }
        });
    }
});