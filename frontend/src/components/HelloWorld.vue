<template>
    <div class="name">
        <div v-if="loading" class="loading">
            Loading...
        </div>

        <div v-if="name" class="content">

            <h1>Hello, {{ name }}</h1>

        </div>

        <div v-if="isError" class="content">

            <h1>An error has occured:</h1>
            <p> {{ error.message }}</p>

        </div>
    </div>
</template>

<script lang="js">
    import Vue from 'vue';
    import axios from 'axios'

    export default Vue.extend({
        data() {
            return {
                loading: false,
                isError: false,
                name: "",
                error: null
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchName();
        },
        watch: {
            // call again the method if the route changes4
            '$route': 'fetchName'
        },
        methods: {
            fetchName() {
                this.name = "";
                this.loading = true;
                this.isError = false;

                axios
                    .get('/api/getname')
                    .then(response => response.data)
                    .then(json => this.name = json.name)
                    .catch(error => {
                        console.log(error)
                        this.isError = true;
                        this.error = error
                        this.name = "";
                    })
                    .finally(() => {
                        this.loading = false;
                    })
            }
        }
    });
</script>