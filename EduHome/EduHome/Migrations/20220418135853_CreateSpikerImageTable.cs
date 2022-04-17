using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class CreateSpikerImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCategory_Categories_CategoryId",
                table: "EventCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCategory_Event_EventId",
                table: "EventCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_EventImage_Event_EventId",
                table: "EventImage");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEvent_Event_EventId",
                table: "SpeakerEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEvent_Speaker_SpeakerId",
                table: "SpeakerEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerImage_Speaker_SpeakerId",
                table: "SpeakerImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpeakerEvent",
                table: "SpeakerEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Speaker",
                table: "Speaker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventCategory",
                table: "EventCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "SpeakerEvent",
                newName: "SpeakerEvents");

            migrationBuilder.RenameTable(
                name: "Speaker",
                newName: "Speakers");

            migrationBuilder.RenameTable(
                name: "EventCategory",
                newName: "EventCategories");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakerEvent_SpeakerId",
                table: "SpeakerEvents",
                newName: "IX_SpeakerEvents_SpeakerId");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakerEvent_EventId",
                table: "SpeakerEvents",
                newName: "IX_SpeakerEvents_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventCategory_EventId",
                table: "EventCategories",
                newName: "IX_EventCategories_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventCategory_CategoryId",
                table: "EventCategories",
                newName: "IX_EventCategories_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpeakerEvents",
                table: "SpeakerEvents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Speakers",
                table: "Speakers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventCategories",
                table: "EventCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventCategories_Categories_CategoryId",
                table: "EventCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventCategories_Events_EventId",
                table: "EventCategories",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventImage_Events_EventId",
                table: "EventImage",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEvents_Events_EventId",
                table: "SpeakerEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEvents_Speakers_SpeakerId",
                table: "SpeakerEvents",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerImage_Speakers_SpeakerId",
                table: "SpeakerImage",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCategories_Categories_CategoryId",
                table: "EventCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCategories_Events_EventId",
                table: "EventCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_EventImage_Events_EventId",
                table: "EventImage");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEvents_Events_EventId",
                table: "SpeakerEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEvents_Speakers_SpeakerId",
                table: "SpeakerEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerImage_Speakers_SpeakerId",
                table: "SpeakerImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Speakers",
                table: "Speakers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpeakerEvents",
                table: "SpeakerEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventCategories",
                table: "EventCategories");

            migrationBuilder.RenameTable(
                name: "Speakers",
                newName: "Speaker");

            migrationBuilder.RenameTable(
                name: "SpeakerEvents",
                newName: "SpeakerEvent");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Event");

            migrationBuilder.RenameTable(
                name: "EventCategories",
                newName: "EventCategory");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakerEvents_SpeakerId",
                table: "SpeakerEvent",
                newName: "IX_SpeakerEvent_SpeakerId");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakerEvents_EventId",
                table: "SpeakerEvent",
                newName: "IX_SpeakerEvent_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventCategories_EventId",
                table: "EventCategory",
                newName: "IX_EventCategory_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventCategories_CategoryId",
                table: "EventCategory",
                newName: "IX_EventCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Speaker",
                table: "Speaker",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpeakerEvent",
                table: "SpeakerEvent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventCategory",
                table: "EventCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventCategory_Categories_CategoryId",
                table: "EventCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventCategory_Event_EventId",
                table: "EventCategory",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventImage_Event_EventId",
                table: "EventImage",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEvent_Event_EventId",
                table: "SpeakerEvent",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEvent_Speaker_SpeakerId",
                table: "SpeakerEvent",
                column: "SpeakerId",
                principalTable: "Speaker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerImage_Speaker_SpeakerId",
                table: "SpeakerImage",
                column: "SpeakerId",
                principalTable: "Speaker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
