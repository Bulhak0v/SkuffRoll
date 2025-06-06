package com.example.skuffrollmobileclient.data.model

import com.google.gson.annotations.SerializedName

data class EventDto(
    @SerializedName("id")
    val id: Int,

    @SerializedName("campaign_id")
    val campaignId: Int?,

    @SerializedName("name")
    val name: String,

    @SerializedName("description")
    val description: String?,

    @SerializedName("icon")
    val icon: String?,

    @SerializedName("x_coordinate")
    val xCoordinate: Double?,

    @SerializedName("y_coordinate")
    val yCoordinate: Double?
)
