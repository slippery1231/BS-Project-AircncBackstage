//<template>
//    <div id="app">
//        <Toast />
//        <div class="layout-main">
//            <router-view v-if="isRouterAlive" />
//        </div>
//    </div>
//</template>

export default {
    name: '#app',
    provide() {
        return {
            reload: this.reload
        }
    },
    data() {
        return {
            isRouteAlive: true
        }
    },
    methods: {
        reload() {
            this.isRouteAlive = false
            this.$nextTick(function () {
                this.isRouteAlive = true
            })
        }
    },

}