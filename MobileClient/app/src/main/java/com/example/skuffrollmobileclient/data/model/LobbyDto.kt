package com.example.skuffrollmobileclient.data.model

import com.google.gson.annotations.SerializedName

data class LobbyDto(
    @SerializedName("id") val id: Int,
    @SerializedName("host_id") val hostId: Int?,
    @SerializedName("name") val name: String,
    @SerializedName("campaign_id") val campaignId: Int?
)
