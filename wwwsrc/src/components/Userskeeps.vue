<template>
    <div class="row created-keeps text-center">
        <h1>Your Keeps</h1>
        <div class="col-12-sm" v-for="keep in keeps">
            <div class="keepview">

                <button class="keep-title" type="button" data-toggle="modal" @click="getKeep(keep.id)" data-target="#selectedKeep">
                    <h4>
                        <b>{{keep.name}}</b>
                    </h4>
                </button>
                <h6>{{keep.description}}</h6>
                <img :src="keep.image" width="150" height="150">
            </div>
            <div class="empty"></div>
        </div>
        <div class="modal fade" id="selectedKeep" tabindex="-1" role="dialog" aria-labelledby="selectedKeepLabel">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h2 class="modal-title" id="keepModal">{{activekeep.name}}</h2>
                        <h6 class="modal-description">{{activekeep.description}}</h6>
                    </div>
                    <div class="modal-body">
                        <img :src="activekeep.image" style="max-width: 100%">
                        <div class="public" v-if="activekeep.public == 'FALSE'">
                            <button type="button" class="btn-default btn-lg btn-success makePublic" @click="makePublic(activekeep)">Make Keep Public</button>
                        </div>

                    </div>
                    <div class="modal-footer text-center">
                        <button type="button" class="btn-default btn-lg btn-danger delete" @click="removeKeep(activekeep)">Delete Keep</button>
                    </div>
                </div>
            </div>
        </div>

    </div>
</template>

<script>
    export default {
        name: "Userkeeps",
        data() {
            return {

            }
        },
        mounted() {
            this.$store.dispatch('getUserKeeps', this.user.id)
        },
        computed: {
            user() {
                return this.$store.state.user
            },
            keeps() {
                return this.$store.state.keeps
            },
            activekeep() {
                return this.$store.state.activekeep
            }
        },
        methods: {
            getKeep(id) {
                this.$store.dispatch('getKeep', id)
            },
            removeKeep(activekeep) {
                var keepId = activekeep.id
                var userId = activekeep.userId
                this.$store.dispatch('removeKeep', { keepId, userId })
            },
            makePublic(keep) {

                keep.public = 'TRUE'
                this.$store.dispatch('updateKeep', keep)
            }
        }
    }

</script>

<style scoped>
    .delete {
        display: flex;
        justify-content: center;
    }

    .created-keeps {
        color: white;
    }

    .keepview {
        background-color: rgb(218, 216, 216);
        border-width: 5px;
        border-color: black;
        color: black;
        padding-bottom: 1em;
        padding-top: 1em;
    }
    .empty {
        padding: 2%;
    }
    .modal-header {
        color: black;
    }
</style>