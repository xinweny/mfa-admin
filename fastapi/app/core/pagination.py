from typing import TypeVar
from math import ceil
from sqlalchemy import func, select
from sqlalchemy.orm import Session, DeclarativeBase
from sqlalchemy.sql.expression import Select
from pydantic import BaseModel, Field

T = TypeVar('T', bound=DeclarativeBase)

class PaginationRequest(BaseModel):
    page: int = Field(1, ge=1)
    limit: int | None = Field(None, ge=1)

class PaginationMetadata(BaseModel):
    current_page: int
    total_pages: int
    total_count: int

def paginate(
    query: Select[tuple[T]],
    params: PaginationRequest,
    db: Session,
) -> tuple[Select[tuple[T]], PaginationMetadata]:
    page = params.page
    limit = params.limit

    offset = None if limit is None else ((page - 1) * limit)

    paginated_query = query.offset(offset).limit(limit)

    total_count = int(db.execute(
        select(func.count).select_from(query.subquery())
    ).scalar_one()) or 0

    total_pages = ceil(total_count / limit) if limit is not None else 1

    return (
        paginated_query,
        PaginationMetadata(
            current_page=page if page <= total_pages else total_pages,
            total_pages=total_pages,
            total_count=total_count,
        ),
    )
